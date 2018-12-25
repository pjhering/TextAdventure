﻿using System;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;
using static System.Console;
using MySql.Data.MySqlClient;

namespace TxtAdv
{
    class DAL
    {
        #region Properties

        /// <summary>Returns true if the args passed to the constructor resolve to an existing local or remote file.</summary>
        public bool FileExits { get; set; }

        /// <summary>Returns error message string for the end user.</summary>
        public string ErrorMessage { get; set; }

        private Model _gameFile = null;
        /// <summary>Contains a Model object if the constructor can resolve the file location and parse the json.</summary>
        public Model GameFile
        {
            get
            {
                if (_gameFile == null)
                {
                    _gameFile = new Model();
                }
                return _gameFile;
            }
            set
            {
                if (value != null) _gameFile = value;
            }
        }

        private string[] _args { get; set; }

        #endregion

        #region Constructor

        /// <summary>Data Access Layer accepts three arguments: agrs[0] 'open','save','delete' args[1] 'remote','local' args[2] 'fileName'</summary>
        public DAL(string[] args)
        {
            _args = args;
            switch (this._args[0].ToLower())
            {
                case "open":
                    ReadFile();
                    break;
                case "save":
                    CreateOrUpdateFile();
                    break;
                case "delete":
                    DeleteFile();
                    break;
                default:
                    FileExits = false;
                    ErrorMessage = "error: no action selected";
                    break;
            }
        }

        #endregion

        #region CRUD functions

        private void CreateOrUpdateFile()
        {
            ErrorMessage = "save feature is not implemented.";
        }

        //Expect args[1] = "local" or "remote"
        private void ReadFile()
        {
            if (string.IsNullOrEmpty(this._args[1]) || string.IsNullOrEmpty(this._args[2]))
            {
                ErrorMessage = "usage:\n... TxtAdv open local <model-json-file>\n... TxtAdv open remote fileName";
                return;
            }
            switch (this._args[1])
            {
                case "local":
                    GetLocalFile();
                    break;
                case "remote":
                    GetRemoteFile();
                    break;
            }
        }

        private void GetLocalFile()
        {
            FileInfo file = new FileInfo(this._args[2]);
            if (file.Exists)
            {
                try
                {
                    StreamReader reader = file.OpenText();
                    string json = reader.ReadToEnd();
                    GameFile = JsonConvert.DeserializeObject<Model>(json);
                    this.FileExits = true;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }

        private void GetRemoteFile()
        {
            string connectionString = ConfigurationManager.AppSettings["gamesConnection"];
            MySqlConnection conx = new MySqlConnection(connectionString);
            MySqlCommand cmd = conx.CreateCommand();
            cmd.CommandText = "SELECT * FROM TxtAdv_game WHERE Name = '" + _args[2] + "'";
            //cmd.CommandText = "SELECT * FROM TxtAdv_game WHERE Name = 'defaultGame'";
            try
            {
                conx.Open();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string json = reader["JSON"].ToString();
                GameFile = JsonConvert.DeserializeObject<Model>(json);
            }
            conx.Close();
            this.FileExits = true;
        }

        private void DeleteFile()
        {
            ErrorMessage = "Delete feature is not implemented.";
        }

        #endregion
    }
}