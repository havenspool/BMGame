using UnityEngine;
using System.Collections;
/**
 * jski
 */
public class CenterInfo{

	public static int frame = 30;

	private static AudioManager _audioManager;
	public static AudioManager audioManager{
		get{
			return _audioManager;
		}
		set{
			_audioManager = value;
		}
	}

	private static ActorManager _actorManager;
	public static ActorManager actorManager{
		get{
			return _actorManager;
		}
		set{
			_actorManager = value;
		}
	}

	private static Game _game;
	public static Game game{
		get{
			return _game;
		}
		set{
			_game = value;
		}
	}

	private static UIGame _uigame;
	public static UIGame uigame{
		get{
			return _uigame;
		}
		set{
			_uigame = value;
		}
	}

}
