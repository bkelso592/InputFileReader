#include <iostream>
#include <fstream>
#include <vector>
#include <string>

std::vector<std::string> ReadFileLines(const std::string& filePath) {
    std::vector<std::string> lines;
    std::ifstream file(filePath);

    if (file.is_open()) {
        std::string line;
        while (std::getline(file, line)) {
            lines.push_back(line);
        }
        file.close();
    } else {
        std::cerr << "File not found: " << filePath << std::endl;
    }

    return lines;
}

void MergeAndWrite(const std::vector<std::string>& file1Lines, const std::vector<std::string>& file2Lines, const std::string& outputPath) {
    std::ofstream outputFile(outputPath);

    size_t i = 0, j = 0;

    while (i < file1Lines.size() && j < file2Lines.size()) {
        if (file1Lines[i] < file2Lines[j]) {
            outputFile << file1Lines[i] << std::endl;
            i++;
        } else {
            outputFile << file2Lines[j] << std::endl;
            j++;
        }
    }

    while (i < file1Lines.size()) {
        outputFile << file1Lines[i] << std::endl;
        i++;
    }

    while (j < file2Lines.size()) {
        outputFile << file2Lines[j] << std::endl;
        j++;
    }

    outputFile.close();
}

int main() {
    std::string file1Path = "c:\\Users\\bk91062\\Documents\\File1.txt";
    std::string file2Path = "c:\\Users\\bk91062\\Documents\\File2.txt";
    std::string outputPath = "output.txt";

    // Read lines from both files
    std::vector<std::string> file1Lines = ReadFileLines(file1Path);
    std::vector<std::string> file2Lines = ReadFileLines(file2Path);

    // Merge the lines and write to output file
    MergeAndWrite(file1Lines, file2Lines, outputPath);

    std::cout << "Files merged successfully." << std::endl;

    return 0;
}
