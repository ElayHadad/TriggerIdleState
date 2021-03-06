# WhenIDLE
Some PCs have a lot of background applications running and
consuming RAM, thus IDLE state won't be triggered.
Hence, I wrote an application to activate PC's IDLE state on a custom trigger.

## How is this working ##
Basically the idea is to check whether mouse movement isn't detected for custom amount of time and if the ram usage is at a certain point, if so trigger IDLE state.
However you can take this code/concept/sketch and suite it to yourself.

## How to use ##
The interface is mostly intuitive.
  1. Write the RAM usage percentage you want to trigger IDLE state
  2. Click on 'set'
  3. Reopen the application
  4. Press start and it will trigger the IDLE state whenever your PC hits the set RAM usage percentage

Please note that right now the application is in beta state! It was written mostly to serve others who want to use the code and apply the idea in a better way.
