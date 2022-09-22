namespace Cosmos.FilePond.Models
{
    public class Case
    {
        /// <summary>
        /// File pond Case ID
        /// </summary>

        public Case()
        {
            Attachments = new List<Attachment>();
        }
        public int CaseId { get; set; }

        public List<Attachment> Attachments { get; set; }
    }

    /// <summary>
    /// File Attachment
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// Attachment Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// File Name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// File Type
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// File Size
        /// </summary>
        public long FileSize { get; set; }
        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; }
        /// <summary>
        /// File deleted
        /// </summary>
        public bool Deleted { get; set; }
        /// <summary>
        /// Created on date/time
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// File pond Case ID
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        /// Url to file
        /// </summary>
        public string Url { get;  set; }
    }
}
