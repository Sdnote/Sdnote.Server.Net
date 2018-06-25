using System;
using System.Collections.Generic;
using SdnoteServer.Dto;

namespace SdnoteServer.Service
{
    public class TodoService
    {
        public static TodoService Current { get; } = new TodoService();

        public List<Todo> Todos { get; }

        private TodoService()
        {
            Todos = new List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    TdName = "Just Test!",
                    TdTime = DateTime.Now
                },
                new Todo
                {
                    Id = 2,
                    TdName = "Just Test again!",
                    TdTime = DateTime.Now.AddHours(1)
                }
            };
        }
    }
}