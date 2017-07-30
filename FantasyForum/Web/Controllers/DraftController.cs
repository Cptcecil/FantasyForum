using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DraftController : Controller
    {
        private ApplicationDbContext _context;
        static Random random;

        public DraftController()
        {
            _context = new ApplicationDbContext();
            random = new Random();
        }

        [Authorize]
        public ActionResult RandomTeamOrder()
        {
            var users = _context.Users.ToList();
            var wrestlers = _context.Wrestlers.ToList();

            var draftUsers = users.Select(x => new UserMatch()
            {
                User = new FantasyUserDto()
                {
                    Name = x.Name,
                    Bio = x.Bio,
                    TagLine = x.TagLine,
                    PictureUrl = x.PictureUrl
                },
                Wrestler = new Wrestler(),
                Order = 0
            }).ToList();
            draftUsers.Add(new UserMatch()
            {
                User = new FantasyUserDto()
                {
                    Name = "The Meat Massager",
                    Bio = "ESPN random draft.  From the dark crags of the netherworld, when all meat was consumed.  From the depths emerged The Massager, the Meat Massager of Doom.",
                    TagLine = "",
                    PictureUrl = "http://img10.deviantart.net/6a3d/i/2017/140/5/c/gluttonous_demon_by_davesrightmind-d8koq6v.png"
                },
                Wrestler = new Wrestler(),
                Order = 0
            });
            draftUsers.Add(new UserMatch()
            {
                User = new FantasyUserDto()
                {
                    Name = "Gettleman 'The Fuck' Outtahere",
                    Bio = "ESPN random draft.",
                    TagLine = "",
                    PictureUrl = "http://a.espncdn.com/wireless/mw5/r1/images/bookmark-icons/espn_icon-72x72.min.png"
                },
                Wrestler = new Wrestler(),
                Order = 0
            });

            var randomUsers = RandomPermutation<UserMatch>(draftUsers);
            foreach(var user in randomUsers)
            {
                if(users.Any(x=>x.Name == user.User.Name)) {
                    var fantasyUser = users.SingleOrDefault(x => x.Name == user.User.Name);
                    if (fantasyUser.UserWrestlers.Any())
                    {
                        foreach(var wrestler in fantasyUser.UserWrestlers.OrderBy(x=>x.Order).Select(x=>x.Wrestler))
                        {
                            if (wrestlers.Contains(wrestler))
                            {
                                user.Wrestler = wrestler;
                                wrestlers.Remove(wrestler);
                                break;
                            }
                        }
                    } else
                    {
                        var randomWrestler = RandomPermutation<Wrestler>(wrestlers).First();
                        user.Wrestler = randomWrestler;
                        wrestlers.Remove(randomWrestler);
                    }
                } else
                {
                    var randomWrestler = RandomPermutation<Wrestler>(wrestlers).First();
                    user.Wrestler = randomWrestler;
                    wrestlers.Remove(randomWrestler);
                }
            }
            //pick random user order
            return View(randomUsers.ToList());
        }

        [Authorize]
        public ActionResult MyTeam()
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);
            return View(user.UserWrestlers?.OrderBy(x => x.Order).Select(x => x.Wrestler).ToList());
        }

        [Authorize]
        public ActionResult ChooseTeam()
        {
            var wrestlers = _context.Wrestlers.ToList();
            return View(wrestlers);
        }

        [Authorize]
        public ActionResult AddWrestlers(string wrestlers)
        {
            var wrestlerIds = JsonConvert.DeserializeObject<int[]>(wrestlers);

            var user = _context.Users.SingleOrDefault(x => x.Email == User.Identity.Name);

            _context.UserWrestlers.RemoveRange(_context.UserWrestlers.Where(x => x.UserId == user.Id));

            UserWrestler toAddUserWrestler = new UserWrestler();
            for (int i = 1; i <= wrestlerIds.Length; i++)
            {
                toAddUserWrestler = new UserWrestler
                {
                    UserId = user.Id,
                    WrestlerId = wrestlerIds[i - 1],
                    Order = i
                };
                user.UserWrestlers.Add(toAddUserWrestler);
            }

            _context.SaveChanges();
            return RedirectToAction("MyTeam");
        }
        
        public static IEnumerable<T> RandomPermutation<T>(IEnumerable<T> sequence)
        {
            T[] retArray = sequence.ToArray();


            for (int i = 0; i < retArray.Length - 1; i += 1)
            {
                int swapIndex = random.Next(i, retArray.Length);
                if (swapIndex != i)
                {
                    T temp = retArray[i];
                    retArray[i] = retArray[swapIndex];
                    retArray[swapIndex] = temp;
                }
            }

            return retArray;
        }
    }
}