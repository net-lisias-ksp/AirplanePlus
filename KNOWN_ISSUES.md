# Airplane+ :: Known Issues

* The new `APanimateGenericEchokinesis` is definitively, absolutely, out of the questionly 😜 Experimental. Do not use it in your projects yet.
	+ It's spendthrift, wasting CPU cycles when not needed.
	+ I didn't tested it yet on anything but the Cargo Bays animations.
	+ I don't even know if the current interface is adequate yet.
* The Experimental `s3hull*` and `s2hull*` parts have an internal glitch where the two mesh variants are being drawn at the same time.
	+ This is going t cost me some brain cells to fix, but it's doable - I only don't know how yet. 😃
* The Experimental `s2hull2x` and `s2hull4x` parts have a weird texturing glitch on Editor, but interestingly things are fine on Flight.
	+ Don't ask, I don't have the slightest idea why, the other new experimental parts are fine.
	+ Well, the thing is Experimental for a reason! 😃
* The old S2 and new S4 Booms probably should have a variant with Fuel, no?
* The Piston engines are terribly overpowered
	+ Apparently there were converted from `FSEngine` to `ModuleEngine` without converting HP to Thrust correctly. 

- - -

* RiP : Research in Progress
* WiP : Work in Progress
