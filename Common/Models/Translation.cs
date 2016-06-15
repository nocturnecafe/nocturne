using System.ComponentModel.DataAnnotations;

namespace Nocturne.Common.Models
{
    public class Translation
    {
        public int TranslationId { get; set; }

        [MaxLength(40960)]
        public string Value { get; set; }

        public int MultiLangStringId { get; set; }
        public MultiLangString MultiLangString { get; set; }

        [MaxLength(12)]
        public string Culture { get; set; }

    }
}