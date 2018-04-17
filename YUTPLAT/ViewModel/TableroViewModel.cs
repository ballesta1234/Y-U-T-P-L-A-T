namespace YUTPLAT.ViewModel
{
    public class TableroViewModel
    {        
        public TableroViewModel()
        {
            this.AnioTableroViewModel = new AnioTableroViewModel();
        }

        public string Titulo { get; set; }
        public string AnioTableroID { get; set; }
        public AnioTableroViewModel AnioTableroViewModel { get; set; }
    }
}

