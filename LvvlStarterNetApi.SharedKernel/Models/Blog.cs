﻿using LvvlStarterNetApi.SharedKernel.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LvvlStarterNetApi.SharedKernel.Models
{
    public class Blog : IBlog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<string> Comments { get; set; }
    }
}