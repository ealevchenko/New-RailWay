namespace EFKIS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KIS.BufferInputSostav")]
    public partial class RWBufferInputSostav
    {
        public int id { get; set; }

        public DateTime datetime { get; set; }

        public int doc_num { get; set; }

        public int id_station_from_kis { get; set; }

        public int? way_num_kis { get; set; }

        public int? napr { get; set; }

        public int id_station_on_kis { get; set; }

        public int? count_wagons { get; set; }

        public int? count_set_wagons { get; set; }

        public int? natur { get; set; }

        public int? status { get; set; }

        [StringLength(1000)]
        public string list_wagons { get; set; }

        [StringLength(1000)]
        public string list_no_set_wagons { get; set; }

        [StringLength(1000)]
        public string message { get; set; }

        public DateTime? close { get; set; }

        [StringLength(100)]
        public string close_user { get; set; }

        [StringLength(250)]
        public string close_comment { get; set; }

        [StringLength(4000)]
        public string list_update_wagons { get; set; }







    }
}
