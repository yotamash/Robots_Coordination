using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robots_Cordination
{
    internal class Satellite
    {
        Robot[] robotsArray;
        int[] finalKey;
        int keySize;
        long numberOfGuessesOld;
        long numberOfGuessesNew;
        int keyBitFoundOld = 0;
        int keyBitFoundNew = 0;

        Random rnd = new Random();

        public Satellite(int numRobots, int keySize)
        {
            this.keySize = keySize;
            finalKey = new int[keySize];
            Array.Fill(finalKey, -1);
            robotsArray = new Robot[numRobots];
            for (int i = 0; i < numRobots; i++)
            {
                robotsArray[i] = new Robot(keySize);
            }
        }

        public async Task CalculateKeyOldMethod()
        {
            numberOfGuessesOld = 0;
            keyBitFoundOld = 0;
            await Task.Run(() =>
            {
                keyBitFoundOld = 0;
                while (keyBitFoundOld != keySize)
                {
                    int keyBit = rnd.Next(2);
                    numberOfGuessesOld++;
                    bool found = true;
                    for (int i = 0; found && i < robotsArray.Length; i++)
                    {
                        found = found && robotsArray[i].CheckBase(keyBit);
                    }
                    if (found)
                    {
                        finalKey[keyBitFoundOld] = keyBit;
                        keyBitFoundOld++;
                    }
                    if (numberOfGuessesOld % 200000000 == 0)
                    {
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        public async Task CalculateKeyNewMethod()
        {
            numberOfGuessesNew = 0;
            keyBitFoundNew = 0;
            await Task.Run(() =>
            {
                keyBitFoundNew = 0;
                while (keyBitFoundNew != keySize)
                {
                    for (int i = 0; i < robotsArray.Length; i++)
                    {
                        int keyBit = rnd.Next(2);
                        numberOfGuessesNew++;
                        while (!robotsArray[i].CheckBase(keyBit))
                        {
                            numberOfGuessesNew++;
                            keyBit = rnd.Next(2);
                        }
                    }
                    keyBitFoundNew++;
                }
            });
        }

        public long GetNumberOfOperationsOld()
        {
            return numberOfGuessesOld;
        }

        internal int GetCurrentKeySizeOld()
        {
            return keyBitFoundOld;
        }

        public long GetNumberOfOperationsNew()
        {
            return numberOfGuessesNew;
        }

        internal int GetCurrentKeySizeNew()
        {
            return keyBitFoundNew;
        }

        public async Task UpdateNumOperationOld(System.Windows.Controls.TextBox oldTotalTime_)
        {
            oldTotalTime_.Text = GetNumberOfOperationsOld().ToString();
            while (keySize > GetCurrentKeySizeOld())
            {
                await Task.Delay(1000);
                oldTotalTime_.Text = GetNumberOfOperationsOld().ToString();
            }
            oldTotalTime_.Text = GetNumberOfOperationsOld().ToString();
        }

        public async Task UpdateNumBitsFoundOld(System.Windows.Controls.TextBox bitsFound)
        {
            bitsFound.Text = GetCurrentKeySizeOld().ToString() + " Out of " + keySize;

            while (keySize != GetCurrentKeySizeOld())
            {
                await Task.Delay(1000);
                bitsFound.Text = GetCurrentKeySizeOld().ToString() + " Out of " + keySize;
            }
            bitsFound.Text = GetCurrentKeySizeOld().ToString() + " Out of " + keySize;

        }

        public async Task UpdateNumOperationNew(System.Windows.Controls.TextBox newTotalTime_)
        {
            newTotalTime_.Text = GetNumberOfOperationsNew().ToString();
            while (keySize > GetCurrentKeySizeNew())
            {
                await Task.Delay(1000);
                newTotalTime_.Text = GetNumberOfOperationsNew().ToString();
            }
            newTotalTime_.Text = GetNumberOfOperationsNew().ToString();
        }

        public async Task UpdateNumBitsFoundNew(System.Windows.Controls.TextBox bitsFound_New)
        {
            bitsFound_New.Text = GetCurrentKeySizeNew().ToString() + " Out of " + keySize;

            while (keySize != GetCurrentKeySizeNew())
            {
                await Task.Delay(1000);
                bitsFound_New.Text = GetCurrentKeySizeNew().ToString() + " Out of " + keySize;
            }
            bitsFound_New.Text = GetCurrentKeySizeNew().ToString() + " Out of " + keySize;

        }
    }
}
