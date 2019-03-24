# Word Guess Game

#### Lab03-Word-Guess-Game
##### *Author: Andrew Curtis*

## Description

This is a C# console app that allows the user to play a word-guessing game similar to Hangman. The user interface allows the user to add new words to the bank of "mystery words" from which a random word will be picked for them to guess in the game. The user can view all the words in the word bank and also remove words from the bank. 


## Getting Started

Clone this repository to your local machine.
```
$ git clone [repo url here]
```

#### To run the program from Visual Studio:
Select `File` -> `Open` -> `Project/Solution`

Next navigate to the location where you cloned the repository.

Double-click on the `Lab03-Word-Guess-Game` directory.

Then select and open `Lab03-Word-Guess-Game.sln`


## Visuals

##### Home Screen at Application Start

![Home Screen at Application Start](/assets/home-screen.png)

##### Gameplay

![Gameplay](/assets/)

##### Add New Word

![Add New Word]()

##### View All Words in Word Bank

![View All Words in Word Bank]()


## Change Log

#### v1.1

`2019-03-22`: Built out initial CRUD methods and first few tests

`2019-03-23`: Added main gameplay logic 

`2019-03-24`: Built out UI and added last couple tests


## Attribution

* I learned from the Microsoft C# docs and Stack Overflow how to use Array.Exists to check whether an array contains a given string. 
* For the process of deleting a given word from my word bank file, I got the idea to create and then delete a temp file from Stack Overflow. 
