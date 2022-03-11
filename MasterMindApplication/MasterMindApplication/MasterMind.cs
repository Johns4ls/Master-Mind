namespace MasterMindApplication
{
    public class MasterMind
    {
        #region Variables
        private string Answer { get; set; }
        private string Attempt { get; set; }
        private bool IsCorrect { get; set; }
        private int Attempts { get; set; }
        #endregion
        #region Constructor
        public MasterMind()
        {
            Initialize();
        }
        #endregion
        #region Methods
        private void Initialize()
        {
            GenerateAnswer();
            Attempts = 0;
            IsCorrect = false;
        }
        private void GenerateAnswer()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                this.Answer +=(random.Next(1, 6).ToString());
            }
        }
        private bool ValidateAnswer()
        {
            if(this.Attempt == string.Empty)
            {
                Console.WriteLine("Input cannot be blank");
                return false;
            }
            else if(this.Attempt.Count() != 4)
            {
                Console.WriteLine("Input must be 4 integers");
                return false;
            }
            try
            {
                int.Parse(Attempt);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Answer must be an integer");
                return false;
            }
            return true;
        }

        private string CheckAnswer()
        {
            List<string> pluses = new List<string>();
            List<string> minuses = new List<string>();
            string retval = String.Empty;

            if (this.Attempt.Equals(this.Answer))
            {
                //The answer is entirely correct.
                this.IsCorrect = true;
                return "++++";
            }
            for(int i = 0; i < 4; i++)
            {
                //Correct character, in the correct location
                if(Attempt[i] == this.Answer[i])
                {
                    pluses.Add("+");
                }
                else
                {
                    //The character is contained in the answer, but in a different location.
                    if(this.Answer.Any(x=> x.Equals(this.Attempt[i])))
                    {
                        minuses.Add("-");
                    }
                }
            }


            //Concatenate our string of +,- and return the value.
            pluses.ForEach(x => {

                retval += x;
            });
            minuses.ForEach(x => {

                retval += x;
            });
            return retval;
        }
        public void StartGame()
        {
            Console.WriteLine("Input a guess: ");
            while (this.Attempts <= 10 && !IsCorrect)
            {
                this.Attempt = Console.ReadLine();
                if (this.ValidateAnswer())
                {
                    Console.WriteLine(CheckAnswer());
                    Console.WriteLine("Please try again: ");
                }
                this.Attempts++;
            }
            if (!IsCorrect)
            {
                Console.WriteLine("I'm Sorry, you lose. The correct answer was: " + this.Answer);
            }
        }
        #endregion
    }
}
