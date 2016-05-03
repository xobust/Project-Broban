# Contributing

## Commit messages

For the commit messages, write them with the following points in mind:

- Write the messages in imperative form, `Add new feature` instead of `Added new feature`.
- Capital letters at the beginning of the sentence.
- No period at the end of the sentence.
- Keep your messages brief and make sure the sentence is short enough to
not cause a line break (happens around 70 characters).

Emojis are implemented in the commit messages and the following emojis are used like this:

Commit type | Emoji
---------------- | ------------
Bugfix	         | :ok_hand: `:ok_hand:`
Documentation    | :books:  `:books:`
Work in progress | :construction: `:construction:`
Feature		 | :v: `:v:`

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

When you are done with the feature/fix/update, send a pull request to `master`. Someone else will then review
your code and merge it to `master` if it looks good :)

## Coding standard

We use mostly use pascal case for the naming of classes, methods and other nameable things:  
https://msdn.microsoft.com/en-us/library/x2dbyw72(v=vs.71).aspx
