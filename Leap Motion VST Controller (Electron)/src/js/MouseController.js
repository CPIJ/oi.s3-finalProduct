const robot = require('robotjs');

module.exports = class MouseController {
  constructor() {
    this.isDown = false;
  }

  move(pos) {
    robot.moveMouse(pos.x, pos.y);
  }

  enableDrag(shouldEnable) {
    if (shouldEnable) {
      if (!this.isDown) {
        robot.mouseToggle('down');
        this.isDown = true;
      }
    } else {
      if (this.isDown) {
        robot.mouseToggle('up');
        this.isDown = false;
      }
    }
  }

  drag(pos) {
    robot.dragMouse(pos.x, pos.y)
  }
}