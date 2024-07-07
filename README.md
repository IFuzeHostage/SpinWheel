# SpinWheel
A simple package for integrating SpinWheel with rewards to your game
##Reward Data
SpinWheel operates with [RewardData](Scripts/Data/RewardData.cs) objects. You can use [RewardDataEntity](Scripts/Data/ScriptableObjects/RewardDataEntry.cs) scriptable objects or write your own code to pass data to [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs).
##Reward Controller
SpinWheel gets available rewards and generates a reward using [ISpinWheelController](Scripts/Domain/Interfaces/ISpinWheelController.cs). You can extend this interface for any custom processing of rewards, like server calls etc. Project contains a default implementation of this interface in [RandomSpinWheelController](Scripts/Domain/RandomSpinWheelController.cs). This implementation is used by default when passing [SpinWheelRewardsData](Scripts/Data/SpinWheelRewardsData.cs) to [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs).
##Sample Scene
You can check a [Sample Scene](Sample/SampleScene.unity) to get a recommended way to start using this package. Then you can write your own Initializers and interactions with buttons, windows, controllers etc.