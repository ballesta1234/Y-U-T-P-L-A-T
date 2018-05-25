namespace YUTPLAT.ViewModel
{
    public class TableroViewModel
    {        
        public TableroViewModel()
        {
            this.AnioTableroViewModel = new AnioTableroViewModel();
            this.AreaTableroViewModel = new AreaViewModel();
        }

        public string Titulo { get; set; }

        public string AnioTableroID { get; set; }
        public AnioTableroViewModel AnioTableroViewModel { get; set; }

        public string AreaTableroId { get; set; }
        public AreaViewModel AreaTableroViewModel { get; set; }
    }
}

