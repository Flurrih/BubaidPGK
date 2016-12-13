using UnityEngine;
using System;
using System.IO;
using System.Xml.Serialization;

[Serializable]
public class GameInput {

    public struct Axis
    {
        [XmlIgnore]
        public float value { get; set; }
        public string AxisName { get; set; }
    }

    [Serializable]
    public class PlayerInput
    {
        public int playerNumber { get; private set; }
        public KeyCode Jump { get; set; }
        public KeyCode Dash { get; set; }
        public KeyCode Kick { get; set; }
        public KeyCode Release { get; set; }
        public KeyCode Skill { get; set; }
        public KeyCode Reset { get; set; }
        public Axis AxisVertical1 { get; set; }
        public Axis AxisHorizontal1 { get; set; }
        public Axis AxisVertical2 { get; set; }
        public Axis AxisHorizontal2 { get; set; }

        public PlayerInput() { }

        public PlayerInput(int playerNumber, KeyCode Jump, KeyCode Dash, KeyCode Kick, KeyCode Release, KeyCode Skill, KeyCode Reset, Axis AxisVertical1, Axis AxisHorizontal1, Axis AxisVertical2, Axis AxisHorizontal2)
        {
            this.playerNumber = playerNumber;
            this.Kick = Kick;
            this.Jump = Jump;
            this.Dash = Dash;
            this.Release = Release;
            this.Skill = Skill;
            this.AxisVertical1 = AxisVertical1;
            this.AxisHorizontal1 = AxisHorizontal1;
            this.AxisVertical2 = AxisVertical2;
            this.AxisHorizontal2 = AxisHorizontal2;
        }
    }

    public PlayerInput player1 { get; set; }
    public PlayerInput player2 { get; set; }

    public static void Save(GameInput gameInput, string filename)
    {
        XmlSerializer ser = new XmlSerializer(typeof(GameInput));
        TextWriter writer = new StreamWriter(filename);

        ser.Serialize(writer, gameInput);
        writer.Close();
    }

    public GameInput() { }

    public GameInput(PlayerInput player1, PlayerInput player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    public static GameInput Load(String filename)
    {
        XmlSerializer ser = new XmlSerializer(typeof(GameInput));

        FileStream fs = new FileStream(filename, FileMode.Open);

        GameInput GI = (GameInput) ser.Deserialize(fs);
        return GI;
    }

    public static GameInput LoadDefault()
    {
        XmlSerializer ser = new XmlSerializer(typeof(GameInput));

        FileStream fs = new FileStream("GameInput.xml", FileMode.Open);

        GameInput GI = (GameInput)ser.Deserialize(fs);
        return GI;
    }

    public PlayerInput getPlayerInput(int i)
    {
        if (i == player1.playerNumber)
        {
            return player1;
        }
        else if (i == player2.playerNumber)
        {
            return player2;
        }
        else return null;
    }

}
