osu!toolkit
===========

Definition
----------

**osu!toolkit** is an extended library to use in different osu! related projects, e.g. extended AIMod or similar.

Releases
--------

Currently there are no releases since it's a early development state.
Feel free to clone this repository and build it by yourself

Build
-----

**osu!toolkit** has a project file for Visual Studio 2010 (see [src/osu!toolkit.sln](src/osu!toolkit.sln)).

* Open the project file.
* Build the project osu!toolkit.

Testing
-------
**osu!toolkit** is full unit tested. For this there two projects:

###osu!tests
This project is for unit tests. You can run tests using [NUnit](http://nunit.org/?p=download) by opening project library. You have to build this project first.

Please take care to modify tests to your current environment since they are strong depending on your settings (osu!) and beatmaps

###osu!integrationtests
This projects is supposed to use for complex tests and - for example - benchmarking. It is a console application using the library. Just write your tests, build and run.

Please notify that you should build and then use the release output. Debug output may be very slow!

Usage
-----
See [doc](doc/README.md) directory

Requirements
------------

See [REQUIREMENTS](REQUIREMENTS) file

License
-------
See [LICENSE](LICENSE) file

Supported Projects
------------------
osu!toolkit will allow project support for projects working with this library. This means direct advertising in project list and support in development progress. For more details please refer [support](support).

Want to help?
-------------

If you find an issue in my code or want to share some useful additions for the library, please fork this project, commit your changes and send a pull request.

If it is doable and if it fits the library and coding style maybe it will get included.

Help and Ideas
---------------
Please post your issue if you need some help or post your idea if I should add something useful.

See also
--------
* [osu!: https://osu.ppy.sh](https://osu.ppy.sh)
* [My osu! profile page: https://osu.ppy.sh/u/1998846](https://osu.ppy.sh/u/1998846)