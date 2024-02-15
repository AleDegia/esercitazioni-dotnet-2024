const score1 = document.querySelector('#score--0');
const score2 = document.getElementById('score--1');   //non metto il # perchè può essere solo quello con getElementById
const diceEl = document.querySelector('.dice');
const btnNew = document.querySelector('.btn--new');
const btnRoll = document.querySelector('.btn--roll');
const btnHold = document.querySelector('.btn--hold');

//starting conditions
score1.textContent = 0;
score2.textContent = 0;
diceEl.classList.add('hidden');        //aggiungo classe 'hidden' all'elemento con classe 'dice'

let currentScore = 0;

// Rolling dice funcionality
btnRoll.addEventListener('click', function(){
    //Generating a random dice roll
    const dice = Math.trunc(Math.random()*6)+1;
    //display dice
    diceEl.classList.remove('hidden');
    diceEl.src = `./imgs/dice-${dice}.png`;        //parte una foto di una faccia del dado in maniera random
    //se esce l'1 deve cambiare giocatore
    if(dice!==1)
    {
        currentScore+= dice;
    } else {
        
    }
})
