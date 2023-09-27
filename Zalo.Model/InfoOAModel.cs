namespace Zalo.Model
{
    public class InfoOAModel
    {
        public InfoDataModel Data { get; set; }
        public int Error { get; set; }
        public string Message { get; set; }
    }

    public class InfoDataModel
    {
        public string OAId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVerified { get; set; }
        public int OAType { get; set; }
        public string CateName { get; set; }
        public int NumFolower { get; set; }
        public string Avatar { get; set; }
        public string Cover { get; set; }
        public string PackageName { get; set; }
    }
}