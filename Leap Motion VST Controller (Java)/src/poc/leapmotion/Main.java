package poc.leapmotion;

import com.leapmotion.leap.Controller;
import com.leapmotion.leap.Listener;

import javax.swing.*;
import java.awt.*;
import java.io.IOException;

;

public class Main {

    public static void main(String[] args) {

        System.out.println("Press Enter to quit...");

        JFrame f = new JFrame("Test");
        MyPanel panel = new MyPanel();
        f.add(panel);
        f.setAlwaysOnTop(true);
        f.setExtendedState(JFrame.MAXIMIZED_BOTH);
        f.setUndecorated(true);
        f.setVisible(true);
        f.setBackground(new Color(0, 0, 0, 0));

        new Thread(() -> {
            Controller controller = new Controller();
            controller.setPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);

            Listener listener = new TestListener(f, panel);
            controller.addListener(listener);

            try {
                System.in.read();
            } catch (IOException e) {
                e.printStackTrace();
            }


            controller.removeListener(listener);
        }).start();

    }
}


