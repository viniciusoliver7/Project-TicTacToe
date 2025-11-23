using System.ComponentModel;
using System.Dynamic;

namespace TicTacToePlay
{
    
    class TicTacToe
    {   
        public string Name{get;}
        private int winers;
        static List<int> positions = new List<int>{1,2,3,4,5,6,7,8,9};
        List<int> marks= new List<int>{};
        private Char Icon;
        static private string leyout;


        public TicTacToe(char Icon,String Name="player" )
        {   
            this.Name = Name;
            this.Icon=Icon;
            leyout = "[1]|[2]|[3]\n---|---|---\n[4]|[5]|[6]\n---|---|---\n[7]|[8]|[9]\n---|---|---";
        }   


        public Boolean Add(short position)
        {
            if(positions.Contains(position) == true)
            {
                string positionTrad= position.ToString();
                leyout = leyout.Replace(positionTrad , Convert.ToString(this.Icon));
                positions.Remove(position);
                this.marks.Add(position);
                return true;
            }
            else
            {
              return false;
            }


        }

        public byte endGame()
        {
            

            if (positions.Count == 0)
            {
                return 1;
            }
            if (VerifyList(1,2,3) ||
                VerifyList(4,5,6) ||
                VerifyList(7,8,9) ||
                VerifyList(1,4,7) || 
                VerifyList(2,5,8) ||
                VerifyList(3,6,9) ||
                VerifyList(3,5,7) ||
                VerifyList(1,5,9)
                 )
            {
                this.winers +=1;
                return 2; 
            }
            else
            {

                return 3;
            }
        } 


        private Boolean VerifyList(int postition1,int postition2, int postition3)
        {
            if (this.marks.Contains(postition1) && this.marks.Contains(postition2) && this.marks.Contains(postition3))
            {
              return true;
            }

            else
            {
                return false;
            }

        }
        

        public void ShowGame()
        {
         Console.WriteLine($"\n{leyout}");
        }

        public int geVictories()
        { 
            return this.winers;
        }

        public void restarALLGame()
        {
            leyout = "[1]|[2]|[3]\n---|---|---\n[4]|[5]|[6]\n---|---|---\n[7]|[8]|[9]\n---|---|---";
            positions= new List<int>{1,2,3,4,5,6,7,8,9};
        }

        public void restatPlayerGame()
        {
            this.marks= new List<int>{};

        }
    }
    
}