package poc.leapmotion;

import com.leapmotion.leap.*;
import com.leapmotion.leap.Frame;

import javax.swing.*;
import java.awt.*;
import java.awt.event.InputEvent;

public class TestListener extends Listener {

    private final MyPanel panel;
    private final JFrame frame;

    public TestListener(JFrame frame, MyPanel panel) {
        this.panel = panel;
        this.frame = frame;
    }

    @Override
    public void onFrame(Controller controller) {
//        frame.toFront();
        Frame frame = controller.frame();
        if (!frame.hands().isEmpty()) {

            Hand hand = frame.hands().get(0);

            if (hand.isValid()) {
                InteractionBox box = frame.interactionBox();
                Vector pos = box.normalizePoint(hand.palmPosition());
                Dimension screen = Toolkit.getDefaultToolkit().getScreenSize();
                Vector screenPos = new Vector(screen.width * pos.getX(), screen.height - pos.getY() * screen.height, 0);

                try {
                    Robot robot = new Robot();

                    robot.mouseMove((int) screenPos.getX(), (int) screenPos.getY());
                    panel.setPosition(screenPos);

                    if (hand.pinchStrength() > 0.80) {
                        robot.mousePress(InputEvent.BUTTON1_DOWN_MASK);
                        robot.mouseMove((int) screenPos.getX(), (int) screenPos.getY());
                    } else {
                        robot.mouseRelease(InputEvent.BUTTON1_DOWN_MASK);
                    }
                } catch (AWTException e) {
                    e.printStackTrace();
                }
            }
        }
    }
}
