using UnityEngine;

public class RobotColor {
    public Color teamColor;
    public Color idColor;

    public RobotColor(Color teamColor, Color idColor) {
        this.teamColor = teamColor;
        this.idColor = idColor;
    }
}

static public class RobotColorPicker {

    static private Color[] idColors = new Color[] { Color.red, Color.green, Color.magenta };

    static RobotColor BlueTeam(int id) {
        var teamColor = Color.blue;
        return new RobotColor(teamColor, idColors[id]);
    }

    static RobotColor YellowTeam(int id) {
        var teamColor = Color.yellow;
        return new RobotColor(teamColor, idColors[id]);
    }
}
