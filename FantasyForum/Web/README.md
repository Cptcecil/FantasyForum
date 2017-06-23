# FantasyForum

6/13/2017 Discussed Rebase vs Merge
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
git push origin :dev    (delete branch)
git branch -d dev   (DELETE get rid of local)

6/7/2017 - Project and Repository Setup

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