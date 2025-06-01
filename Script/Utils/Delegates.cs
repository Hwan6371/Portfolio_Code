using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ServerResponse(string json, string errorMessage);
public delegate void BackgroundChanged(ImageErrorType errorMessage);
public delegate void ImageChanged(ImageErrorType errorMessage);
public delegate void ImageLoaded(Dictionary<string, Sprite> sprite);
public delegate void InGameImageLoaded(Dictionary<string, Sprite> sprite);
public delegate void AddressableImageInGame(string _name, GameType _gameType, InGameStep _inGameStep, Sprite _sprite);
public delegate void AddressableImageInGameError(ImageErrorType errorMessage);
