﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarciaExamenP3.Models;

namespace GarciaExamenP3.Services
{
    internal class AGCharacterDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AGCharacterDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
            _database.CreateTableAsync<AGCharacter>().Wait();
            _database.CreateTableAsync<AGThumbnail>().Wait();
        }

        public Task<List<AGCharacter>> GetCharactersAsync()
        {
            return _database.Table<AGCharacter>().ToListAsync();
        }

        public async Task<int> SaveCharacterAsync(AGCharacter character)
        {
            if (character.Thumbnail != null)
            {
                await _database.InsertAsync(character.Thumbnail);
                character.ThumbnailId = character.Thumbnail.Id;
            }
            return await _database.InsertAsync(character);
        }
    }
}
