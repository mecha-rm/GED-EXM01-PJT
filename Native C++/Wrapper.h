#pragma once

#include "CheckpointTimeLogger.h"

#ifdef __cplusplus
extern "C" // convert to C Code
{
#endif

	// resets the logger. This should be called to start the logger as well.
	PLUGIN_API void ResetLogger();

	// saves the checkpoint time, starting a new timer until the next checkpoint is reached.
	PLUGIN_API void SaveCheckpointTime();

	// returns the total time that has passed
	PLUGIN_API float GetTotalTime();

	// gets the time since the last checkpoint was reached.
	PLUGIN_API float GetTimeSinceLastCheckpoint();

	// gets the time it took to reach a given checkpoint.
	// returns 0 if the index is out of bounds.
	PLUGIN_API float GetCheckpointTime(int index);

	// returns the number of checkpoints reached.
	PLUGIN_API int GetNumberOfCheckpoints();

	// update logger
	PLUGIN_API void UpdateLogger(float deltaTime);

#ifdef __cplusplus
}
#endif

