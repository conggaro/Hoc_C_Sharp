using System;

namespace MyApp
{
    /// <summary>
    /// lớp ModelOrg dùng để làm khuôn mẫu
    /// cho các bản ghi
    /// </summary>
    public class ModelOrg
    {
        /// <summary>
        /// thuộc tính Id
        /// </summary>
        public long Id { get; set; }



        /// <summary>
        /// thuộc tính Code
        /// </summary>
        public string? Code { get; set; }



        /// <summary>
        /// thuộc tính Name
        /// </summary>
        public string? Name { get; set; }



        /// <summary>
        /// thuộc tính ParentId
        /// </summary>
        public long? ParentId { get; set; }
    }
}