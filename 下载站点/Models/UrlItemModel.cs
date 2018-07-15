using System;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace 下载站点.Models
{
    public class UrlItemModel
    {
        [AutoIncrement,PrimaryKey]
        public long Id { get; set; }
        [ForeignKey(typeof(TypeItemModel), OnDelete = "CASCADE", OnUpdate = "CASCADE")]
        public long TypeItemModelId { get; set; }
        [Reference]
        public TypeItemModel TypeItemModel { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public byte[] IconBytes { get;set; }
        public string FilePath { get; set; }
        public long Clicked { get; set; }
        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime CreatedDate { get; set; }
    }

    public class TypeItemModel
    {
        [PrimaryKey,AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
        public long Sort { get; set; }
        [Default(OrmLiteVariables.SystemUtc)]
        public DateTime CreatedDate { get; set; }
    }
}