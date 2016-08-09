# CLTokenInputView-Xamarin-iOS
A Xamarin iOS version of the TokenField (See To: field in Mail and Messages).

![Image](http://cl.ly/image/1y3Q0u0q1N3H/iOS%20Simulator%20Screen%20Shot%20Jan%2028,%202015,%204.30.15%20PM.png)
[![Screencap GFY](http://zippy.gfycat.com/ImpressiveRapidGelding.gif)](http://gfycat.com/ImpressiveRapidGelding)

## About

`CLTokenInputView` is an almost pixel perfect replica of the input portion iOS's native contacts picker, used in Mail.app and Messages.app when composing a new message.

Check out the sample view controller which uses CLTokenInputView to see how to incorporate it into your UI. We use this in our apps at [Cluster Labs, Inc.](https://cluster.co).

Check out [a Swift port of this library](https://github.com/rlaferla/CLTokenInputView-Swift) by [@rlaferla](https://github.com/rlaferla). 

### Note 
It ***does not*** provide the autocomplete drop down and matching; you must provide that yourself, so that `CLTokenInputView` can remain very generic and flexible. You can copy what the sample app is doing to show an autocompleting table view and maintain a list of the selected "tokens".

## Usage

To run the example project, clone the repo, and open the xamarin project. You should use this on iOS 7 and up.

To use this in your code, you should add an reference of `CLTokenInputView` bining to your project. 

# Author

* [Jigar Maheshwari](http://twitter.com/jigar0809)

# Inspiration
iOS Native Version : https://github.com/clusterinc/CLTokenInputView

# License

          The MIT License (MIT)
        
          Copyright (c) 2016 Jigar M
        
          Permission is hereby granted, free of charge, to any person obtaining a copy
          of this software and associated documentation files (the "Software"), to deal
          in the Software without restriction, including without limitation the rights
          to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
          copies of the Software, and to permit persons to whom the Software is
          furnished to do so, subject to the following conditions:
          
          The above copyright notice and this permission notice shall be included in all
          copies or substantial portions of the Software.
          
          THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
          IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
          FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
          AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
          LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
          OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
          SOFTWARE.
