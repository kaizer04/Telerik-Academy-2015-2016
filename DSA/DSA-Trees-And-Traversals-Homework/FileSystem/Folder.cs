namespace FileSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        private ICollection<File> files;
        private ICollection<Folder> subFolders;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new List<File>();
            this.subFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public ICollection<File> Files
        {
            get
            {
                return this.files;
            }

            set
            {
                this.files = value;
            }
        }

        public ICollection<Folder> SubFolders
        {
            get
            {
                return this.subFolders;
            }

            set
            {
                this.subFolders = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        public long GetSizeFromHere()
        {
            return this.Files.Sum(f => f.Size) + this.SubFolders.Sum(f => f.GetSizeFromHere());
        }
    }
}