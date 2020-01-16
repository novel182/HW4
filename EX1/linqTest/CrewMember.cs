using System;

namespace linqTest
{
    class CrewMember : IDisposable
    {
        private bool disposed = false;
        public string Fname {
            get;
            set;
        }
        public string Lname {
            get;
            set;
        }
        public string Position {
            get;
            set;
        }
        public string Rank {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }

        public CrewMember(string fname = "none", string lname= "none", string position= "none", string age = "none", string rank = "none") {
            Fname = fname;
            Lname = lname;
            Position = position;
            Rank = rank;
            Age = age;
        }

        public void dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        } 

        private void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                //If you disposing equals true, dispose all managed resources
                if (disposing)
                {
                    //Dispose Mange resources
                    Console.WriteLine("It is disposing");
                    //Clean up unmanaged resource here
                }
            }
            disposed = true;
            Console.WriteLine("Disposed");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        ~CrewMember()
        {
            //Call our helper method
            //Specifying "false" significant that the GC triggered the cleanup
            CleanUp(false);
        }
    }
}
