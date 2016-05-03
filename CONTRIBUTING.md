# Contributing

Commit type | Emoji
---------------- | ------------
Bugfix	         | :ok_hand: `:ok_hand:`
Documentation    | :books:  `:books:`
Work in progress | :construction: `:construction:`

## Implementing new features and working with branches 

Before implementing a new feature, create a new issue with the `feature` label and either `game` or `website` depending
which is appropriate. 

When implementing the feature, create a new _feature branch_ and work on that. 

Whenever you start working on something new, create a new branch and commit to that.

Use the following name conventions:

- `feature/{name}` for new features
- `fix/{name}` for fixing bugs
- `update/{name}` for refactoring or updating code

`{name}` should be replaced with a few words describing of what the branch is about, without the { and }.

Emojis are implemented in the commit messages and the following emojis are used like this:

When you are done with the feature/fix/update, send a pull request to `master`. Someone else will then review
your code and merge it to `master` if it looks good :)
