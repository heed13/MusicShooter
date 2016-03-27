 #pragma strict
 
 public var minimapCamera : Camera;
 
 private var correctionFactor : float = 1.0;
 private var baseRect : Rect;
 private var adjustedRect : Rect;
 
 function Start() 
 {
     CorrectMinimapViewport();
 }
 
 function CorrectMinimapViewport() 
 {
     baseRect = minimapCamera.rect;
     
     var correctionFactor : float = 1.6 / Camera.main.aspect;
     
     adjustedRect = new Rect( baseRect.x - ( ( baseRect.width * correctionFactor ) - baseRect.width ), baseRect.y , baseRect.width * correctionFactor, baseRect.height );
     
     minimapCamera.rect = adjustedRect;
 }