const Leap = require('leapjs');
const Vector = require('../js/Vector');
const MouseController = require('../js/MouseController');

module.exports = class LeapMotionController {
  constructor(onResize) {
    this.controller = new Leap.Controller();
    this.controller.connect()
    this.controller.on('connect', () => this.isConnected = true)
    this.controller.on('frame', (frame) => this.onFrame(frame, this))

    this.isConnected = false;
    this.resize = onResize;
    this.mouse = new MouseController();
  }

  onFrame(frame, controller) {
    if (!controller.isConnected) return 
    if (frame.hands.length === 0) return;
    
    const hand = frame.hands[0];
    const box = frame.interactionBox;
    const point = Vector.fromArray(box.normalizePoint(hand.palmPosition));
    const pos = new Vector(screen.width * point.x, screen.height - point.y * screen.height);
  
    controller.resize(pos);

    if (hand.pinchStrength < 0.80) {
      this.mouse.move(pos);
    }

    if (hand.pinchStrength > 0.80) {
      this.mouse.enableDrag(true);
      this.mouse.drag(pos);
    } else {
      this.mouse.enableDrag(false);
    }
  }
}