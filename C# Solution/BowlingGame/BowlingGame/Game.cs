using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class Game
    {
        private int[] rolls;
        private int currentRoll = 0;
        private int _score;

        public Game()
        {
            rolls = new int[21];
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score = CalculateStrikeBonus(score, frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score = CalculateSpareBonus(score, frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score = CalculateOpenFrame(score, frameIndex);
                    frameIndex += 2;
                }
            }

            return score;
        }

        public void Roll(int pins)
        {
            _score += pins;
            rolls[currentRoll++] = pins;
        }

        private bool IsSpare(int i)
        {
            return rolls[i] + rolls[i + 1] == 10;
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private int CalculateOpenFrame(int score, int frameIndex)
        {
            score += rolls[frameIndex] + rolls[frameIndex + 1];
            return score;
        }

        private int CalculateSpareBonus(int score, int frameIndex)
        {
            score += 10 + rolls[frameIndex + 2];
            return score;
        }

        private int CalculateStrikeBonus(int score, int frameIndex)
        {
            score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
            return score;
        }
    }
}
