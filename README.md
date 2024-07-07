# SpinWheel
A simple package for integrating SpinWheel with rewards to your game
## Reward Data
SpinWheel operates with [RewardData](Scripts/Data/RewardData.cs) objects. You can use [RewardDataEntity](Scripts/Data/ScriptableObjects/RewardDataEntry.cs) scriptable objects or write your own code to pass data to [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs).
## Reward Data Entities
You can pass Data to [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs) by generating it via you own logic. Or use Data Entities that come with the package. [RewardDataEntity](Scripts/Data/Entity/RewardDataEntry.cs) contains a single RewardData, and [RewardDataListHolder](Scripts/Data/Entity/RewardDataListHolder.cs) holds lists of reward data, which you can use to initialize [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs) by calling Open() method. 
## ISpinWheelController
SpinWheel gets available rewards and generates a reward using [ISpinWheelController](Scripts/Domain/Interfaces/ISpinWheelController.cs). You can extend this interface for any custom processing of rewards, like server calls etc. Project contains a default implementation of this interface in [RandomSpinWheelController](Scripts/Domain/RandomSpinWheelController.cs). This implementation is used by default when passing [SpinWheelRewardsData](Scripts/Data/SpinWheelRewardsData.cs) to [SpinWheelView](Scripts/Presentation/SpinWheel/SpinWheelView.cs).
## SpinWheelView
SpinWheelView is a MonoBehaviour that represents the actual wheel window. It requires a reference to [SpinWheelSlice](Scripts/Presentation/SpinWheel/SpinWheelSlice.cs) prefab and a reference to [SpinWheelAnimator](Scripts/Presentation/SpinWheel/SpinWheelAnimator.cs)
## SpinWheelAnimator
Responsibel for animating spinning of a wheel, starting, stopping, and stopping at a specific reward
## Sample Scene
You can check a [Sample Scene](Sample/SampleScene.unity) to get a recommended way to start using this package. Then you can write your own Initializers and interactions with buttons, windows, controllers etc.
