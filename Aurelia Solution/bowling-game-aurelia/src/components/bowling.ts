export class Bowling {
  public score: number = 0;
  public frameMessage: string = "Roll your first frame to start!";
  public rollMessage: string = "Roll a Frame!";

  private gameOver: boolean = false;
  private rolls = [];
  private frameIndex: number = 0;

  public roll(pinsHitFirst: number, pinsHitSecond: number) {
    // If the game is done, don't allow any more rolls until its reset
    if (this.gameOver) {
      return;
    }

    // Check if the game is over (if 10 frames were rolled)
    if (this.rolls.length === 9) {
      this.gameOver = true;
      this.frameMessage = `Game done! Final score ${this.score}`;
      this.rollMessage = "Reset the game to play again!";
    }
    pinsHitFirst = this.getRandomInt(0, 11);

    const pins: number = 10;
    let rollOne: number = 0;
    let rollTwo: number = 0;
    let rollThree: number = 0;
    let frameScore: number = 0;
    let remainingPins: number = pins - pinsHitFirst;

    rollOne = pinsHitFirst;

    // Strike
    if (rollOne === 10) {
      frameScore = rollOne;
      this.rolls.push([rollOne, 0, this.score]);
      this.score = frameScore * 2 + this.score;
      this.frameMessage = "Rolled a strike!";
      this.frameIndex++;
      return;
    }

    pinsHitSecond = this.getRandomInt(0, remainingPins + 1);

    remainingPins = remainingPins - pinsHitSecond;
    rollTwo = pinsHitSecond;

    // Spare or Open Frame
    if (rollOne + rollTwo === 10) {
      frameScore = rollOne + rollTwo;
      this.frameMessage = "Rolled a spare!";
      this.score = this.score + frameScore;
      this.rolls.push([rollOne, rollTwo, this.score]);
      this.frameIndex++;
      return;
    } else {
      frameScore = rollOne + rollTwo;
      this.score = this.score + frameScore;
      this.frameMessage = "Rolled an open frame!";
      this.frameIndex++;
      this.rolls.push([rollOne, rollTwo, this.score]);
    }
  }

  public resetGame() {
    this.gameOver = false;
    this.rolls = [];
    this.score = 0;
    this.frameIndex = 0;
    this.rollMessage = "Roll a Frame!";
    this.frameMessage = "Roll your first frame to start!";
  }

  private getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
  }
}
