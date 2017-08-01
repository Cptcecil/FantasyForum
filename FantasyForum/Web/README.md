# FantasyForum

-5/13/2017- Discussed Rebase vs Merge
git checkout -b dev        (Create new branch)

git checkout -b feature/titleChange   (Helps to sort, branch)

git stash   (weird local save thing, to switch branches)

git pop   (pull up weird save)

git checkout dev    (do a pull, once both are up to date)
git merge feature/titleChange   (didnt work)
git mergetool   (fix your shit)
COMMIT  git merge

Rebase 
pull both brances, make sure up to date
checkout your dev, branch your need to rebase
checkout dev
git rebase master
git mergetool
git rebase --continue
git push origin :dev    (delete origin branch)
git branch -d dev   (DELETE get rid of local)

-6/7/2017-  Project and Repository Setup

Necessary Installs
- Visual Studios 
- Git Extensions https://github.com/gitextensions/gitextensions/releases/download/v2.49.03/GitExtensions-2.49.03-Setup.msi

Necessary Account Creation
- Git Hub

Tasks Completed
- Created a new Asp.net MVC Project in Visual Studios
- Created a new Repository on GitHub
- Added our team as contributers
- Cloned the repo and committed and pushed our new project

git checkout -b dev        (Create new branch)

git checkout -b feature/titleChange   (Helps to sort, branch)

git stash   (weird local save thing, to switch branches)

git pop   (pull up weird save)

git checkout dev    (do a pull, once both are up to date)
git merge feature/titleChange   (didnt work)
git mergetool   (fix your shit)
COMMIT  git merge


ASSIGNMENT: Make new branch, rebase, update readme with notes
6/14/17
PUBLISHING


-6/22/17-
Document Object Model DOM Element
List of all of the elements inside the element.
Col 4.. 3 columns    12 whole page
Razer is a C# library

When you call an ASP.net app, unless otherwise specificed, home controller gets pinged fist.
MVC 5 empty controller

Create new controller for the FrontPageLayoutController
Views, Create new folder, FrontPageLayout
Create new view, label as index
Build a form, league name, tag line, 
go to dev, pull, go to my branch, rebase dev, checkout dev then merge

-6/26/17-
Fixed FrontPageLayout controller code and FPL folder heirarchy.
Went over columns, size parameters and their properties.
Action Link proper formatting

*Assignment*
Become familiar with column layout and how different screen size changes and effects columns.
Add to FPL Form  TeamName, Tagline, Description? (text area instead of input)
Find out how to set a character limit on regular input type text (50 characters)

-7/20/17-
All html is markup. Javascript etc is considered you code.

7-17-17
Create random number generator in jQuery, to generate wrestlers.
Setup number generator, variables and loop

*Assignment*
pretty up the page, html, css, find hideous pictures for all league memebers

7/31/2017
Rebased Erniebranch, updated site name and logo
Added Datebase (pain in the ass)

*Show Later * 
Issue with NavBar resizing, not responsive. Marshall "Right at 990 pixels, my mouse is too damn fast. Got dang screen is too big"
in Layout - new { area = "" }  What does this mean?
Razor render css
Why do things get bundled into Razer?
DNS, IP Addressess and Ports
Controller action method description of why and how things work