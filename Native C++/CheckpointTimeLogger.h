#pragma once
#include "PluginSettings.h"

#include <vector>

// checkpoint time logger
class PLUGIN_API CheckpointTimeLogger
{
public:
	// resets the logger. This should be called to start the logger as well.
	void ResetLogger();

	// saves the checkpoint time, starting a new timer until the next checkpoint is reached.
	void SaveCheckpointTime();

	// returns the total time that has passed
	float GetTotalTime() const;

	// gets the time since the last checkpoint was reached.
	float GetTimeSinceLastCheckpoint() const;

	// gets the time it took to reach a given checkpoint.
	// returns 0 if the index is out of bounds.
	float GetCheckpointTime(int index);

	// returns the number of checkpoints reached.
	int GetNumberOfCheckpoints() const;

	// update logger
	void UpdateLogger(float deltaTime);

private:
	// saves the amount of time between each checkpoint
	std::vector<float> checkpointTimes;

	// the total time that has passed
	float totalTime = 0.0F;

	// elapsted time since last checkpoint
	float elapsedTime = 0.0F;

protected:


};

