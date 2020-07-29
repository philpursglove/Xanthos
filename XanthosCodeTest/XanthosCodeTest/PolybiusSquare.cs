namespace XanthosCodeTest
{
    public class PolybiusSquare
    {
        private string[,] square = new string[5,5];

        public PolybiusSquare()
        {
            string polybiusAlphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            int column = 0;
            int row = 0;
            for (int i = 0; i < 25; i++)
            {
                string letter = polybiusAlphabet.Substring(i, 1);

                square[column, row] = letter;

                column += 1;
                if (column == 5)
                {
                    column = 0;
                    row += 1;
                }
            }
        }

        public string Encrypt(string cleartext)
        {
            cleartext = NormaliseCleartext(cleartext);

            string ciphertext = string.Empty;

            for (int i = 0; i < cleartext.Length; i++)
            {
                ciphertext += EncodeLetter(cleartext.Substring(i, 1));
            }

            return ciphertext;
        }

        public string Decrypt(string ciphertext)
        {
            string cleartext = string.Empty;

            for (int i = 0; i < ciphertext.Length; i+=2)
            {
                string coordinate = ciphertext.Substring(i, 2);

                cleartext += DecodeLetter(coordinate);
            }

            return cleartext;
        }

        private string DecodeLetter(string coordinate)
        {
            int row = int.Parse(coordinate.Substring(0, 1)) - 1;
            int column = int.Parse(coordinate.Substring(1, 1)) - 1;

            return square[column, row];
        }

        private string NormaliseCleartext(string cleartext)
        {
            return cleartext.ToUpper().Replace("J", "I");
        }

        private string EncodeLetter(string letter)
        {
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (square[c, r] == letter)
                    {
                        return $"{r + 1}{c + 1}";
                    }
                }
            }
            return string.Empty;
        }
    }
}
