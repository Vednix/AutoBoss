using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace AutoBoss
{
	public class Config
	{
		public bool AutoStartEnabled;

		public bool ContinuousBoss;

		public bool OneWave;

		public int MessageInterval = 10;

		public bool EnableDayTimerText;

		public string[] DayTimerText =
		{
			"[Day] Primeira mensagem",
			"[Day] Segunda mensagem",
			"[Day] Terceira mensagem",
			"[Day] Quarta mensagem",
			"[Day] Boss invocados"
		};

		public string DayTimerFinished = "Batalha completa.";

		public bool EnableNightTimerText;

		public string[] NightTimerText =
		{
			"[Night] Primeira mensagem",
			"[Night] Segunda mensagem",
			"[Night] Terceira mensagem",
			"[Night] Quarta mensagem",
			"[Night] Boss invocados"
		};

		public string NightTimerFinished = "Batalha completa.";

		public bool EnableSpecialTimerText;

		public string[] SpecialTimerText =
		{
			"[Special] Primeira mensagem",
			"[Special] Segunda mensagem",
			"[Special] Terceira mensagem",
			"[Special] Quarta mensagem",
			"[Special] Boss invocados"
		};

		public string SpecialTimerFinished = "Batalha completa.";

		public bool AnnounceMinions;
		public int[] MinionsSpawnTimer = {10, 30};

		public Dictionary<string, bool> BossArenas;

		public Dictionary<BattleType, bool> BossToggles = new Dictionary<BattleType, bool>
		{
			{BattleType.Day, false},
			{BattleType.Night, false},
			{BattleType.Special, false}
		};

		public Dictionary<BattleType, bool> MinionToggles = new Dictionary<BattleType, bool>
		{
			{BattleType.Day, false},
			{BattleType.Night, false},
			{BattleType.Special, false}
		};


		public int[] MinionSpawnCount = {2, 5};
		public List<int> DayMinionList;
		public List<int> NightMinionList;
		public List<int> SpecialMinionList;


		public Dictionary<string, Dictionary<int, int>> DayBosses;
		public Dictionary<string, Dictionary<int, int>> NightBosses;
		public Dictionary<string, Dictionary<int, int>> SpecialBosses;

		public void Write(string path)
		{
			File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
		}

		public static Config Read(string path)
		{
			return !File.Exists(path)
				? new Config()
				: JsonConvert.DeserializeObject<Config>(File.ReadAllText(path));
		}
	}
}