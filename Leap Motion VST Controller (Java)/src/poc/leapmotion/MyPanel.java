package poc.leapmotion;

import com.leapmotion.leap.Vector;

import javax.swing.*;
import java.awt.*;

public class MyPanel extends JPanel {

    private int x = 10;
    private int y = 10;

    @Override
    protected void paintComponent(Graphics g) {
        Color c = new Color(0,0,0,0);
        g.setColor(c);
        g.fillRect(0, 0, 1920,1080);
        g.setColor(Color.RED);
        g.fillOval(x, y, 30, 30);
        g.dispose();
    }

    //region getters & setters

    public void setPosition(Vector vector) {
        x = (int) vector.getX();
        y = (int) vector.getY();

        repaint();
    }


    //endregion
}
