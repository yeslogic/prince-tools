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

Documentation for the `Prince` class is provided inline in [PHPDocumentor](http://www.phpdoc.org/) format. You can publish a copy of the documentation using `phpdoc` from within this directory.

## Basic Usage

```
// In this example, we are parsing an HTML file
$prince->setInputType('html');
$prince->setHTML(true);

// Get the contents of the file (or pass it in directly) and set an output location
$prince->convert_string_to_file(file_get_contents('/tmp/document.html'), '/tmp/document.pdf');

```