const LeapMotionController = require('../js/LeapMotionController');
const { ipcRenderer } = require('electron');

const sketch = (p5) => {
  const r = 20, maxSize = 40, minSize = 15, increment = 6;
  let size = 15, controller, canvas;

  p5.setup = () => {
    controller = new LeapMotionController(onResize);
    canvas = p5.createCanvas(window.innerWidth, window.innerHeight)
  }

  p5.draw = () => {
    p5.clear();

    size = controller.mouse.isDown
      ? parseInt(Math.min((size += increment), maxSize))
      : parseInt(Math.max((size -= increment), minSize));

    p5.fill(155, 89, 182);
    p5.stroke(155, 89, 182);
    p5.ellipse(r, r, size)
  }

  p5.keyPressed = () => {
    if (p5.keyCode === p5.SHIFT) {
      ipcRenderer.send('openDevTools');
    }
  }

  const onResize = (pos) => {
    const margin = 30;

    ipcRenderer.send('move', {
      x: parseInt(pos.x - margin),
      y: parseInt(pos.y - margin),
      width: parseInt((margin * 2)),
      height: parseInt((margin * 2)),
    });

    canvas = p5.createCanvas(window.innerWidth, window.innerHeight);
  }
};

module.exports = sketch;