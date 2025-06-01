using System;

public enum GameType
{
    MatchingPairsMix,
    MatchingPairsShake
}

public enum ServerState
{
    Wait,
    Sending,
}

public enum ServerResponseState
{
    Success,
    Error
}

public enum GameState
{
    None,
    Wait,
    Playing,
    Stop,
    End,
    ViewScore,
    Guide
}

public enum Answer
{
    Correct,
    Wrong
}

public enum InGameStep
{
    Pumpkin,
    Flower,
    Ghost,
    Mummy,
    Skull
}

public enum ImageType
{
    Monster,
    Background
}

public enum TouchEffect
{
    Leaf,
    Red,
    Star,
    Water,
    WhiteRotation
}