using System;
using System.Collections;
using System.Collections.Generic;

namespace SdnoteServer.Dto
{
    public class Todo
    {
        public int Id { get; set; }
        public string TdName { get; set; }
        public DateTime TdTime { get; set; }

        public ICollection<Subevent> Subevent { get; set; }
    }

    public class Subevent
    {
        public int Id { get; set; }
        public string SbName { get; set; }
    }
}