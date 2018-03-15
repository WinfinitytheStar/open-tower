﻿using System;

namespace Scripts.LevelEditor.Serialization {

    public enum AddableType {
        NONE,
        STATIC,
        BOOSTER,
        ENEMY
    }

    [Serializable]
    public struct Upload {
        public string LevelJson;
        public string LevelName;
        public string AuthorName;
        public int AuthorID;
        public string DateCreated;
        public string[] UsersAttempted;
        public string[] UsersCompleted;
        public Score[] Leaderboards;

        public Upload(string levelJson, string levelName, string authorName, int authorID, string dateCreated) : this() {
            LevelJson = levelJson;
            LevelName = levelName;
            AuthorName = authorName;
            AuthorID = authorID;
            DateCreated = dateCreated;
            UsersAttempted = new string[0];
            UsersCompleted = new string[0];
            Leaderboards = new Score[0];
        }
    }

    [Serializable]
    public struct Score {
        public int Steps;
        public string DateAchieved;
        public string User;

        public Score(int steps, string dateAchieved, string user) {
            Steps = steps;
            DateAchieved = dateAchieved;
            User = user;
        }
    }

    [Serializable]
    public struct Dungeon {
        public Addable[] Addables;
        public Floor[] Floors;
        public StartingValues StartingValues;

        public Dungeon(Addable[] addables, Floor[] floors, StartingValues startingValues) {
            Addables = addables;
            Floors = floors;
            StartingValues = startingValues;
        }
    }

    [Serializable]
    public struct Floor {
        public int[] Indices; // array of addable array indices

        public Floor(int[] indices) {
            Indices = indices;
        }
    }

    [Serializable]
    public struct StartingValues {
        public int Life;
        public int Power;
        public int Defense;
        public int Stars;
        public int GoldKeys;
        public int BlueKeys;
        public int RedKeys;

        public StartingValues(int life, int power, int defense, int stars, int goldKeys, int blueKeys, int redKeys) {
            Life = life;
            Power = power;
            Defense = defense;
            Stars = stars;
            GoldKeys = goldKeys;
            BlueKeys = blueKeys;
            RedKeys = redKeys;
        }
    }

    [Serializable]
    public class StaticData {
        public TileType TileType;

        public StaticData(TileType tileType) {
            TileType = tileType;
        }
    }

    [Serializable]
    public class BoosterData {
        public int SpriteID;
        public StatType StatToBoost;
        public int AmountBoosted;

        public BoosterData(int spriteID, StatType statToBoost, int amountBoosted) {
            SpriteID = spriteID;
            StatToBoost = statToBoost;
            AmountBoosted = amountBoosted;
        }
    }

    [Serializable]
    public class EnemyData {
        public int SpriteID;
        public int Life;
        public int Power;
        public int Defense;
        public int Stars;

        public EnemyData(int spriteID, int life, int power, int defense, int stars) {
            SpriteID = spriteID;
            Life = life;
            Power = power;
            Defense = defense;
            Stars = stars;
        }
    }

    [Serializable]
    public class Addable {
        public AddableType AddableType;

        public StaticData _staticData;
        public BoosterData _boosterData;
        public EnemyData _enemyData;

        public StaticData StaticData {
            get {
                Util.Assert(AddableType == AddableType.STATIC, "Expected {0}, got {1} instead", AddableType.STATIC, this.AddableType);
                return _staticData;
            }
        }

        public BoosterData BoosterData {
            get {
                Util.Assert(AddableType == AddableType.BOOSTER, "Expected {0}, got {1} instead", AddableType.STATIC, this.AddableType);
                return _boosterData;
            }
        }

        public EnemyData EnemyData {
            get {
                Util.Assert(AddableType == AddableType.ENEMY, "Expected {0}, got {1} instead", AddableType.STATIC, this.AddableType);
                return _enemyData;
            }
        }

        public Addable(StaticData staticData) {
            AddableType = AddableType.STATIC;
            _staticData = staticData;
        }

        public Addable(BoosterData boosterData) {
            AddableType = AddableType.BOOSTER;
            _boosterData = boosterData;
        }

        public Addable(EnemyData enemyData) {
            AddableType = AddableType.ENEMY;
            _enemyData = enemyData;
        }
    }
}