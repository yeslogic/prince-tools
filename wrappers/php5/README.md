# Prince PHP class

The `prince.php` file defines a class called Prince that contains methods that can be called to convert XML and HTML documents into PDF.

_Note that the Prince class is written for PHP 5, and requires modification to work with PHP 4._

## Constructor

When instantiating the Prince class, pass in the full path of the Prince executable to the constructor as a string argument. For example, on Linux or MacOS X:

```
$prince = new Prince('/usr/local/bin/prince');
```

On Windows, be sure to specify the path to the `prince.exe` file located within the `Engine\bin` subfolder of the Prince installation.

## Documentation

Full documentation can be found in the `./docs` folder that came with this file.