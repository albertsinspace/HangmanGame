# Simple Hangman game using C#

The logic here works by first checking the users input is in the chosen word list. This is a list I created by iterating through the randomly chosen word and seperating it by each character. I then check the users input which should be one character and see whether it is present in the chosen word list. If it is present, I will then add that character to a new list called guessed characters. This list I use to check the users current progress on guessing the word. 

The loop then starts, I iterate through each letter in the chosen word list and check whether each letter is present in the guessed characters list, if it is, I reveal the letter otherwise if not I will then just replace it with an underscore and increase the . This is all saved to another list that I iterate through at the beginning in order for the user to see their progress. The hangman stages progress forward if the user did not guess correctly. 

To check whether the user has lost or won, I do a check at the beginning to see if the hangman stage is on the final one and if it is then the user has not guessed the word correctly and I end the game. If the list containing the current progress of the users guesses is equal to that of the chosen word list, then the user wins the game.
