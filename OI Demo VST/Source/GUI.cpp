/*
  ==============================================================================

  This is an automatically generated GUI class created by the Projucer!

  Be careful when adding custom code to these files, as only the code within
  the "//[xyz]" and "//[/xyz]" sections will be retained when the file is loaded
  and re-saved.

  Created with Projucer version: 5.2.0

  ------------------------------------------------------------------------------

  The Projucer is part of the JUCE library - "Jules' Utility Class Extensions"
  Copyright (c) 2015 - ROLI Ltd.

  ==============================================================================
*/

//[Headers] You can add your own extra header files here...
//[/Headers]

#include "GUI.h"


//[MiscUserDefs] You can add your own user definitions and misc code here...
//[/MiscUserDefs]

//==============================================================================
GUI::GUI (OiDemoVstAudioProcessor& p)
    : AudioProcessorEditor(p), processor(p)
{
    //[Constructor_pre] You can add your own custom stuff here..
    //[/Constructor_pre]

    addAndMakeVisible (circelSlider = new Slider ("circleSlider"));
    circelSlider->setRange (0, 127, 1);
    circelSlider->setSliderStyle (Slider::Rotary);
    circelSlider->setTextBoxStyle (Slider::TextBoxBelow, true, 80, 20);
    circelSlider->addListener (this);

    addAndMakeVisible (linearSlider = new Slider ("liniearSlider"));
    linearSlider->setRange (0, 10, 0);
    linearSlider->setSliderStyle (Slider::LinearVertical);
    linearSlider->setTextBoxStyle (Slider::TextBoxRight, false, 80, 20);
    linearSlider->addListener (this);

    addAndMakeVisible (demoVst = new Label ("demoVst",
                                            TRANS("Demo VST\n")));
    demoVst->setFont (Font (15.00f, Font::plain).withTypefaceStyle ("Regular"));
    demoVst->setJustificationType (Justification::centredLeft);
    demoVst->setEditable (false, false, false);
    demoVst->setColour (TextEditor::textColourId, Colours::black);
    demoVst->setColour (TextEditor::backgroundColourId, Colour (0x00000000));

    addAndMakeVisible (leapMotion = new Label ("leapMotion",
                                               TRANS("Leap Motion\n")));
    leapMotion->setFont (Font (15.00f, Font::plain).withTypefaceStyle ("Bold"));
    leapMotion->setJustificationType (Justification::centredLeft);
    leapMotion->setEditable (false, false, false);
    leapMotion->setColour (TextEditor::textColourId, Colours::black);
    leapMotion->setColour (TextEditor::backgroundColourId, Colour (0x00000000));


    //[UserPreSize]
    //[/UserPreSize]

    setSize (332, 310);


    //[Constructor] You can add your own custom stuff here..
    //[/Constructor]
}

GUI::~GUI()
{
    //[Destructor_pre]. You can add your own custom destruction code here..
    //[/Destructor_pre]

    circelSlider = nullptr;
    linearSlider = nullptr;
    demoVst = nullptr;
    leapMotion = nullptr;


    //[Destructor]. You can add your own custom destruction code here..
    //[/Destructor]
}

//==============================================================================
void GUI::paint (Graphics& g)
{
    //[UserPrePaint] Add your own custom painting code here..
    //[/UserPrePaint]

    g.fillAll (Colour (0xff323e44));

    //[UserPaint] Add your own custom painting code here..
    //[/UserPaint]
}

void GUI::resized()
{
    //[UserPreResize] Add your own custom resize code here..
    //[/UserPreResize]

    circelSlider->setBounds (112, 40, 216, 248);
    linearSlider->setBounds (16, 56, 88, 232);
    demoVst->setBounds (24, 32, 150, 24);
    leapMotion->setBounds (24, 16, 150, 24);
    //[UserResized] Add your own custom resize handling here..
    //[/UserResized]
}

void GUI::sliderValueChanged (Slider* sliderThatWasMoved)
{
    //[UsersliderValueChanged_Pre]
    //[/UsersliderValueChanged_Pre]

    if (sliderThatWasMoved == circelSlider)
    {
        //[UserSliderCode_circelSlider] -- add your slider handling code here..
        //[/UserSliderCode_circelSlider]
    }
    else if (sliderThatWasMoved == linearSlider)
    {
        //[UserSliderCode_linearSlider] -- add your slider handling code here..
        //[/UserSliderCode_linearSlider]
    }

    //[UsersliderValueChanged_Post]
    //[/UsersliderValueChanged_Post]
}



//[MiscUserCode] You can add your own definitions of your custom methods or any other code here...
//[/MiscUserCode]


//==============================================================================
#if 0
/*  -- Projucer information section --

    This is where the Projucer stores the metadata that describe this GUI layout, so
    make changes in here at your peril!

BEGIN_JUCER_METADATA

<JUCER_COMPONENT documentType="Component" className="GUI" componentName="" parentClasses="public AudioProcessorEditor"
                 constructorParams="OiDemoVstAudioProcessor&amp; p" variableInitialisers="AudioProcessorEditor(p), processor(p)"
                 snapPixels="8" snapActive="1" snapShown="1" overlayOpacity="0.330"
                 fixedSize="0" initialWidth="332" initialHeight="310">
  <BACKGROUND backgroundColour="ff323e44"/>
  <SLIDER name="circleSlider" id="5eaa0b8587366cbc" memberName="circelSlider"
          virtualName="" explicitFocusOrder="0" pos="112 40 216 248" min="0"
          max="127" int="1" style="Rotary" textBoxPos="TextBoxBelow" textBoxEditable="0"
          textBoxWidth="80" textBoxHeight="20" skewFactor="1" needsCallback="1"/>
  <SLIDER name="liniearSlider" id="e8480704854bd1ca" memberName="linearSlider"
          virtualName="" explicitFocusOrder="0" pos="16 56 88 232" min="0"
          max="10" int="0" style="LinearVertical" textBoxPos="TextBoxRight"
          textBoxEditable="1" textBoxWidth="80" textBoxHeight="20" skewFactor="1"
          needsCallback="1"/>
  <LABEL name="demoVst" id="390661ebf8d9a95e" memberName="demoVst" virtualName=""
         explicitFocusOrder="0" pos="24 32 150 24" edTextCol="ff000000"
         edBkgCol="0" labelText="Demo VST&#10;" editableSingleClick="0"
         editableDoubleClick="0" focusDiscardsChanges="0" fontname="Default font"
         fontsize="15" kerning="0" bold="0" italic="0" justification="33"/>
  <LABEL name="leapMotion" id="7e96a20119e6ad92" memberName="leapMotion"
         virtualName="" explicitFocusOrder="0" pos="24 16 150 24" edTextCol="ff000000"
         edBkgCol="0" labelText="Leap Motion&#10;" editableSingleClick="0"
         editableDoubleClick="0" focusDiscardsChanges="0" fontname="Default font"
         fontsize="15" kerning="0" bold="1" italic="0" justification="33"
         typefaceStyle="Bold"/>
</JUCER_COMPONENT>

END_JUCER_METADATA
*/
#endif


//[EndFile] You can add extra defines here...
//[/EndFile]
