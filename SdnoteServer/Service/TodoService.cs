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
                    TdTime = DateTime.Now,
                    Subevent = new List<Subevent>
                    {
                        new Subevent
                        {
                            Id = 11,
                            SbName = "Subevent for Just Test!"
                        },
                        new Subevent
                        {
                            Id = 12,
                            SbName = "Subevent 2 for Just Test!"
                        }
                    }
                },
                new Todo
                {
                    Id = 2,
                    TdName = "Just Test again!",
                    TdTime = DateTime.Now.AddHours(1),
                    Subevent = new List<Subevent>
                    {
                        new Subevent
                        {
                            Id = 11,
                            SbName = "Subevent for Just Test again!"
                        },
                        new Subevent
                        {
                            Id = 12,
                            SbName = "Subevent 2 for Just Test again!"
                        }
                    }
                }
            };
        }
    }
}