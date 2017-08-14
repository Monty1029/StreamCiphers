using System;
using System.Text;

namespace RC4Cipher
{
    class RC4Cipher 
    {
        static int max;
        static int[] s;
        static byte[] key;

        static void Main() 
        {            
            while (true) {
                Console.WriteLine("Enter a value.");
                string output = "";
                int input = Convert.ToInt32(Console.ReadLine());
                max = input;
                s = new int[max];
                key = new byte[max];
                for (int i = 0; i < max; i++) {
                        s[i] = i;
                }
                for (int a = 0; a < 10; a++) {
                    InitializeS();
                    int randomNumber = GenerateRandomNumber();
                    output += randomNumber.ToString() + "\n";  
                }
                Console.WriteLine(output);      
            }                
        }

        static void InitializeS() {           
            
            int j = 0;
            for (int i = 0; i < max; i++) {
                j = (j + s[i] + key[i % key.Length]) % max;
                Swap(i, j);
            }
        }

        static int GenerateRandomNumber() {
            int i = 0;
            int j = 0;
            i = (i+1) % max;
            j = (j + s[i]) % max;
            Swap(i, j);
            int k = s[(s[i] + s[j]) % max];
            return k;
        }

        static void Swap(int i, int j) {
            int temp = s[i];
            s[i] = s[j];
            s[j] = temp;
        }
    }
}