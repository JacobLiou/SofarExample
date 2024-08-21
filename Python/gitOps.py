import git
import os

path = os.getcwd()
git_dir = os.path.abspath(os.path.join(path, os.pardir))

repo = git.Repo(git_dir)

print(repo.git.status())
# print(repo.git.heads())

if(repo.is_dirty()):
    print("Repo is dirty")

diff = repo.git.diff(repo.head.commit)
print(diff)

